    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Xml;
    using umbraco.BusinessLogic;
    using umbraco.cms.businesslogic.datatype;
    using umbraco.cms.businesslogic.datatype.controls;
    using umbraco.cms.businesslogic.media;
    using umbraco.cms.businesslogic.packager.standardPackageActions;
    using umbraco.DataLayer;
    using umbraco.interfaces;
    using umbraco.IO;
    namespace SocialMediaChannels
    {
        public class AddSocialMediaThemes : IPackageAction
        {
            private readonly static string MediaTypeName = "Social Media Theme";
            private readonly static int LABEL_ID = -92;
            private readonly static int UPLOAD_ID = -90;
            private readonly static int TEXT_ID = -88;
            private readonly static int DATE_ID = -41;
            private readonly static int IMAGE_ID = 1031;
            private readonly static int FOLDER_ID = 1032;
            public IDataType uploadField = new Factory().GetNewObject(new Guid("5032a6e6-69e3-491d-bb28-cd31cd11086c"));
            protected static ISqlHelper SqlHelper
            {
                get
                {
                    return umbraco.BusinessLogic.Application.SqlHelper;
                }
            }
            public string Alias()
            {
                return "SocialMediaChannels_AddSocialMediaThemes";
            }
            public bool Execute(string packageName, XmlNode xmlData)
            {
                bool flag;
                try
                {
                    #region MediaType
                    User adminUser = new User(0);
                    MediaType theme = CreateMediaType(adminUser, MediaTypeName);
                    MediaType folder = MediaType.GetByAlias("Folder");
                    int[] folderStructure = folder.AllowedChildContentTypeIDs;
                    int newsize = folderStructure.Length + 1;
                    Array.Resize(ref folderStructure, newsize);
                    folderStructure[newsize - 1] = theme.Id;
                    folder.AllowedChildContentTypeIDs = folderStructure;
                    MediaType image = MediaType.GetByAlias(MediaTypeName);
                    #endregion
                    #region Theme Images
                    #endregion
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
                return flag;
            }
            public bool Undo(string packageName, XmlNode xmlData)
            {
                bool flag;
                try
                {
                    //remove themes
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
                return flag;
            }
            public XmlNode SampleXml()
            {
                string sample = string.Format("<Action runat=\"install\" undo=\"true/false\" alias=\"{0}\" ></Action>", Alias());
                return helper.parseStringToXmlNode(sample);
            }
            /// <summary>
            /// Create a Media Type.
            /// </summary>
            /// <param name="adminUser"></param>
            /// <param name="mediaTypeName"></param>
            /// <returns></returns>
            private MediaType CreateMediaType(User adminUser, string mediaTypeName)
            {
                MediaType mediaType = MediaType.MakeNew(adminUser, mediaTypeName);
                int[] typeIds =  { FOLDER_ID, IMAGE_ID };
                mediaType.AllowAtRoot = true;
                mediaType.Text = MediaTypeName;
                mediaType.Description = "Container for the Social Media Channel Theme Images";
                mediaType.IsContainerContentType = true;
                mediaType.AllowedChildContentTypeIDs = typeIds;
                //Add properties
                mediaType.AddPropertyType(new DataTypeDefinition(UPLOAD_ID), "umbracoFile", "Upload image");
                mediaType.AddPropertyType(new DataTypeDefinition(LABEL_ID), "umbracoWidth", "Width");
                mediaType.AddPropertyType(new DataTypeDefinition(LABEL_ID), "umbracoHeight", "Height");
                mediaType.AddPropertyType(new DataTypeDefinition(LABEL_ID), "umbracoBytes", "Size");
                mediaType.AddPropertyType(new DataTypeDefinition(LABEL_ID), "umbracoExtension", "Type");
                mediaType.AddPropertyType(new DataTypeDefinition(TEXT_ID), "themeName", "Name of the Social Channel Theme");
                mediaType.AddPropertyType(new DataTypeDefinition(TEXT_ID), "themeUrl", "Url for the Theme");
                mediaType.AddPropertyType(new DataTypeDefinition(TEXT_ID), "createdBy", "Author of the Theme");
                mediaType.AddPropertyType(new DataTypeDefinition(DATE_ID), "createdDate", "Date the Theme was created");
                mediaType.Text = mediaTypeName;
                mediaType.IconUrl = "mediaPhoto.gif";
                mediaType.Save();
                return mediaType;
            }
        }
    }
