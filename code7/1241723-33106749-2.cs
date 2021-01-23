     using Newtonsoft.Json;
        using System;
        using System.Collections.Generic;
        using System.Net.Http;
        using System.Net.Http.Headers;
        
        namespace StupeflixTest
        {
            public class TaskObj
            {
                public Dictionary<string,string> tasks { get; set; }
                public TaskObj(Dictionary<string, string> t)
                {
                    tasks = t;
                }
            }
            public partial class Default : System.Web.UI.Page
            {
                private const string URL = "https://dragon.stupeflix.com/";
                protected async void Page_Load(object sender, EventArgs e)
                {
                    string error = string.Empty;
                    try
                    {
                        Dictionary<string, string> taskParam = new Dictionary<string, string>();
                        taskParam.Add("task_name", "video.create");
                        taskParam.Add("definition", "<movie service='craftsman-1.0'> <body> <stack> <sequence> <effect type='sliding' duration='5.0'> <image filename='http://s3.amazonaws.com/stupeflix-assets/apiusecase/Canyon_Chelly_Navajo.jpg'/> <image filename='http://s3.amazonaws.com/stupeflix-assets/apiusecase/Ha_long_bay.jpg'/> <image filename='http://s3.amazonaws.com/stupeflix-assets/apiusecase/Monument_Valley.jpg'/> </effect> </sequence> </stack> </body></movie>");
                        TaskObj obj = new TaskObj(taskParam);
                        //uncomment the line below to see the resultant json object
                        //string str = JsonConvert.SerializeObject(obj);
                      
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Add("Authorization", "Secret <YourSecret>");
                        client.BaseAddress = new Uri(URL);
        
                        // await response.
                        var response = await client.PostAsJsonAsync("v2/create", obj);  // Blocking call!
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResp = response.Content.ReadAsStringAsync().Result;
                            var jsonArray = JsonConvert.DeserializeObject<dynamic>(jsonResp);
                            string resultKey = jsonArray[0].key.Value;
                            string taskProgressUrl = URL + "v2/status?tasks=" + resultKey;
                        }
                        else
                        {
                            error = string.Format(@"{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                }
            }
        }
