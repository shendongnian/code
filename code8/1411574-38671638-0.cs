    using EPiServer;
    using EPiServer.Core;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;
    using EPiServer.ServiceLocation;
    using EPiServer.Web.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Reflection;
    using System;
    using System.Runtime.Caching;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    namespace NUON.Models.MyCorp
    {
        public class MyCorpPageController : PageController<MyCorpPage>
        {
            public string Index(MyCorpPage currentPage)
            {
                Response.ContentType = "text/json";
                // check if the JSON is cached - if so, return it
                ObjectCache cache = MemoryCache.Default;
                string cachedJSON = cache["myCorpPageJson"] as string;
                if (cachedJSON != null)
                {
                    return cachedJSON;
                }
                var output = new ExpandoObject();
                var outputDict = output as IDictionary<string, object>;
                var pageRouteHelper = ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
                var pageReference = pageRouteHelper.PageLink;
                var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
                var children = contentLoader.GetChildren<PageData>(currentPage.PageLink).OfType<PageData>();
                var toOutput = new { };
                var jsonResultObject = new JObject();
                foreach (PageData page in children)
                {
                    // Name = e.g. BbpbannerProxy . So remove "Proxy" and add the namespace
                    var classType = Type.GetType("NUON.Models.MyCorp." + page.GetType().Name.Replace("Proxy", string.Empty));
                    // Only keep the properties from this class, not the inherited properties
                    jsonResultObject.Add(page.PageName, GetJsonObjectFromType(classType, page));
                }
                // add to cache
                CacheItemPolicy policy = new CacheItemPolicy();
                // expire the cache daily although it will be cleared whenever content changes.
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(1.0);
                cache.Set("myCorpPageJson", jsonResultObject.ToString(), policy);
                return jsonResultObject.ToString();
            }
            [InitializableModule]
            [ModuleDependency(typeof(EPiServer.Web.InitializationModule),
                      typeof(EPiServer.Web.InitializationModule))]
            public class EventsInitialization : IInitializableModule
            {
                public void Initialize(InitializationEngine context)
                {
                    var events = ServiceLocator.Current.GetInstance<IContentEvents>();
                    events.PublishedContent += PublishedContent;
                }
                public void Preload(string[] parameters)
                {
                }
                public void Uninitialize(InitializationEngine context)
                {
                }
                private void PublishedContent(object sender, ContentEventArgs e)
                {
                    // Clear the cache because some content has been updated
                    ObjectCache cache = MemoryCache.Default;
                    cache.Remove("myCorpPageJson");
                }
            }
            private static JObject GetJsonObjectFromType(Type classType, object obj)
            {
                var jsonObject = new JObject();
                var properties = classType.GetProperties(BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly);
                foreach (var property in properties)
                {
                    var jsonAttribute = property.GetCustomAttributes(true).FirstOrDefault(a => a is JsonPropertyAttribute);
                    var propertyName = jsonAttribute == null ? property.Name : ((JsonPropertyAttribute)jsonAttribute).PropertyName;
                    if (property.PropertyType.BaseType == typeof(BlockData))
                        jsonObject.Add(propertyName, GetJsonObjectFromType(property.PropertyType, property.GetValue(obj)));
                    else
                    {
                        var propertyValue = property.PropertyType == typeof(XhtmlString) ? property.GetValue(obj)?.ToString() : property.GetValue(obj);
                        if (property.PropertyType == typeof(string))
                        {
                            propertyValue = propertyValue ?? String.Empty;
                        }
                        jsonObject.Add(new JProperty(propertyName, propertyValue));
                    }
                }
                return jsonObject;
            }
        }
        [ContentType(DisplayName = "MyCorpPage", GroupName = "MyCorp", GUID = "bc91ed7f-d0bf-4281-922d-1c5246cab137", Description = "The main MyCorp page")]
        public class MyCorpPage : PageData
        {
        }
    }
