    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml");//set how to get data
        using (var content = new MultipartFormDataContent())//post by content type multipart/form-data
        {
            var formDatas = this.GetFormDataByteArrayContent(this.GetNameValueCollection(this.gv_FormData));//get collection
            var files = this.GetFileByteArrayContent(this.GetHashSet(this.gv_File));//get collection
            Action<List<ByteArrayContent>> act = (dataContents) =>
            {//declare an action
                foreach (var byteArrayContent in dataContents)
                {
                    content.Add(byteArrayContent);
                }
            };
            act(formDatas);//process act
            act(files);//process act
            try
            {
                var result = client.PostAsync(this.txtUrl.Text, content).Result;//post your request
            }
            catch (Exception ex)
            {
                //error
            }
        }
    }
