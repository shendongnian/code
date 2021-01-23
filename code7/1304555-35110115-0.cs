        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
          
            string result = await WCFRESTServiceCall("GET", "getbg1?Email=" +   
                                                        emailtxtbox.Text + "");
            result = result.Replace("{\"getbg1Result\":", "");
            result = result.Replace("]}", "]");
            List<BG> data = JsonConvert.DeserializeObject<List<BG>>(result);
            int item1 = 0;
            int item2 = 1;
            int item3 = 2;
            int item4 = 0;
            item1 =int.Parse( data[0].Measurement);
            item2 = int.Parse(data[1].Measurement);
            item3 = int.Parse(data[2].Measurement);
            
            List<Tuple<string, int>> myList = new List<Tuple<string, int>>()
            {
                
            
                new Tuple<string, int>(data[0].Date_, item1),
                new Tuple<string, int>(data[1].Date_, item2),
                new Tuple<string, int>(data[2].Date_, item3),            
            };
            (MyChart.Series[0] as LineSeries).ItemsSource = myList;
        }
