    List<CustomClass> users = _userBLL.ReadUsers();
            
                users.ForEach(x => lvUserRoleGroup.Items.Add(
                    new ListViewItem(
                        new string[] { x.UserName, x.IsDisable.ToString(), x.FullName, x.Descriprion }))
                    );
