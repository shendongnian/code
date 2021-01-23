            MenuParentList = _employee.Designation.Role.MenuRoles.GroupBy ( r => r.Menu.ParentID + r.Menu.MenuName ).
                                        	.Select (y => y.First ())
                                            .Select(x => new SMS.Models.ViewModel.DashboardVM.MenuParent
                                            { 
                                                MenuParentID=x.Menu.ParentID ,
                                                MenuParentName=x.Menu.MenuName
                                            }).ToList();
