    public class ItemHelper
    {
        public static bool IsReadingXML { get; set; }
        public static List<Item> ItemList { get; set; }
        public static void BeginReadXMLStream(string currFileName)
        {
            IsReadingXML = true;
            string ImagesRootFolder = "http://www.mywebsite.com/";
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(ImagesRootFolder + currFileName);
            httpRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), httpRequest);
        }
        private static void FinishWebRequest(IAsyncResult result)
        {
            IsReadingXML = true;
            HttpWebResponse httpResponse = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream httpResponseStream = httpResponse.GetResponseStream();
                BuildItemList(httpResponseStream);
            }
        }
        public static void BuildItemList(Stream xmlStream)
        {
            string ImagesRootFolder = "http://www.mywebsite.com/";
            List<Item> returnValue = new List<Item>();
            try
            {
                using (XmlReader myXMLReader = XmlReader.Create((xmlStream)))
                {
                    while (myXMLReader.Read())
                    {
                        if (myXMLReader.Name == "photo")
                        {
                            double tempPrice = 0.0;
                            double.TryParse(myXMLReader.GetAttribute("price"), out tempPrice);
                            returnValue.Add(new Item(
                                myXMLReader.GetAttribute("info"),
                                tempPrice,
                                ImagesRootFolder + myXMLReader.GetAttribute("image"),
                                myXMLReader.GetAttribute("sku")
                                ));
                        }
                    }
                }
            }
            catch { }
            //Done
            ItemList = returnValue;
            IsReadingXML = false;
        }
    }
