    private void UserDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var grid = sender as System.Windows.Controls.DataGrid;
            if (e.Key == Key.Delete)
            {
                //treat each cell individually
                foreach (var item in grid.SelectedCells)
                {
                    User user = item.Item as User;
                    if (user == null)
                        continue;
                    //clear the property of the selected cell
                    foreach (var property in typeof(User).GetProperties())
                    {
                        if (property.Name == item.Column.Header.ToString())
                        {
                            property.SetValue(user, null, null);
                        }
                    }
                    //recreated the user object
                    User newUser = new User
                    {
                        Login = user.Login,
                        Address = user.Address,
                        Email = user.Email,
                        Name = user.Name,
                        Description = user.Description
                    };
                    //remove the old one and place the new one to update collection visually (otherwise DataGrid updates when only double-clicked)
                    var index = UsersToCreate.IndexOf(user);
                    UsersToCreate.Remove(user);
                    UsersToCreate.Insert(index, newUser);
                }
                //now check if any rows are completely empty - if so, then remove from DGV
                List<int> indexesToRemove = new List<int>();
                foreach (var user in UsersToCreate)
                {
                    bool hasValue = false;
                    foreach (var property in typeof(User).GetProperties())
                    {
                        if (property.GetValue(user, null) != null)
                        {
                            hasValue = true;
                        }
                    }
                    if (!hasValue)
                    {
                        indexesToRemove.Add(UsersToCreate.IndexOf(user));
                    }
                }
                //go upside down to avoid index out of range (first remove last rows indexes)
                for (int i = indexesToRemove.Count - 1; i >= 0; i--)
                {
                    var index = indexesToRemove[i];
                    UsersToCreate.RemoveAt(index);
                }
            }
        }
