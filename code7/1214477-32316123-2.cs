        public string CreatePlayer(System.IO.Stream data) {
            
            //convert stream data to StreamReader
            System.IO.StreamReader reader = new System.IO.StreamReader(data);
            //read StreamReader data as string
            string XML_string = reader.ReadToEnd();
            System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            BusinessObjects.Player Player = json_serializer.Deserialize<BusinessObjects.Player>(XML_string);
        
            return BL_CreatePlayer.CreatePlayer(Player);
        }
