    HttpWebRequest request = WebRequest.Create(uri)
               as HttpWebRequest;
            XmlSerializer ser = new XmlSerializer(objetoLista.GetType());
            WebResponse response = request.GetResponse();
            var result = ser.Deserialize(response.GetResponseStream());
            return result;
