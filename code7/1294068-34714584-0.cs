       private async void getCategories()
        {
                Uri = "myWebService";
                http = new HttpClient();
                http.MaxResponseContentBufferSize = Int32.MaxValue;
                var response = await http.GetStringAsync(Uri);
                var rootObject1 = JsonConvert.DeserializeObject<NvBarberry.Models.RootObject>(response);
                List<Categories> v = rootObject1.categories.ToList();
                this.categoryCombo.Items.Clear();
                for (int i = 0; i < v.Count; i++) { 
                    this.categoryCombo.Items.Add(v[i].name);
                       }
                this.categoryCombo.SelectedIndex = 0;
                     }
