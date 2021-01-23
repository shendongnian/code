                var options = new ListFollowerIdsOfOptions { ScreenName = "PutinRF" };
                List<long> All_ods = new List<long>();
                TwitterCursorList<long> followerIDS = ts.ListFollowerIdsOf(options);
                while(followerIDS.NextCursor!=null)
                {
                    options.Cursor = followerIDS.NextCursor;
    
                    All_ods.AddRange(followerIDS.ToArray());
                    //listBox1.Items.Add(All_ods.ToArray());
                    listBox1.DataSource = All_ods;
                    label1.Text = "Получено: " + listBox1.Items.Count.ToString();
                    break;  
                }
