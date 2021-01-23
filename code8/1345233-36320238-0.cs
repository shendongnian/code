    List<Child> childrenList = new List<Child>();
                
                foreach (DataGridViewRow row in childrenDetailsDataGridView.Rows)
                {
                    bool IsRowEmpty = true;
                        if (row.Cells.Count > 0)
                        {
                            Child child = new Child();
                            if (row.Cells["Childname"].Value !=null)
                            {
                                IsRowEmpty = false;
                                child.Childname = row.Cells["Childname"].Value.ToString();
                            }
                            if (row.Cells["Gender"].Value != null)
                            {
                                child.Gender = row.Cells["Gender"].Value.ToString();
                            }
                            if (row.Cells["Age"].Value != null)
                            {
                                child.Age = row.Cells["Age"].Value.ToString();
                            }
                            if (row.Cells["Star"].Value != null)
                            {
                                child.Star = row.Cells["Star"].Value.ToString();
                            }
                            if (row.Cells["Occupation"].Value != null)
                            {
                                child.Occupation = row.Cells["Occupation"].Value.ToString();
                            }
                            if (!IsRowEmpty)
                            {
                                childrenList.Add(child);
                            }
                            
                        }
                }
