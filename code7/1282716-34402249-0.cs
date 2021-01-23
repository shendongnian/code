                            //Deserialise data & send to DataGrid
                            ProcessOrderDetails details = JsonConvert.DeserializeObject<ProcessOrderDetails>(responseBody);
                            //Get number of operations and display to screen
                            int numofitems = details.MaterialList.Count<Materiallist>();
                            txtNumOfMaterials.Text = numofitems.ToString();
                            //Find the last operation
                            var lastone = details.MaterialList.Last<Materiallist>();
                            //Create a new material/operation list
                            var materialList = new List<Materiallist>();
                            //Add the last operation to the list
                            materialList.Add(lastone);
                            //Parse the list to the data grid
                           dataGridProcessOrderDetails.DataSource = materialList;
