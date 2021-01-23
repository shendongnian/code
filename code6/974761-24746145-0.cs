    void webclient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e) {
        ...
        int i = 0;
        foreach (JObject o in a.Children<JObject>())
        {
            foreach (JProperty p in o.Properties())
            {
            ...
            }
            var testData = new TestData(LstLikeNum[i], LstCommentNum[i], ...);
            DataList.Add(testData);
            i++;
        }
    }
