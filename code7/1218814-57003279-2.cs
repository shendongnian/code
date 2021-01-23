    void Dg_Drop(object sender, DragEventArgs e)
            {
                int index = -1;
                DataGrid dg = new DataGrid();
                if (sender is DataGrid)
                {
                    dg = (DataGrid)sender;
                }
                if (rowIndex < 0)
                    return;
                if (dg.Name == "dg1")
                {
                    index = this.GetCurrentRowIndexSupp(e.GetPosition);
                }
                if (dg.Name == "dg2")
                {
                    index = this.GetCurrentRowIndexAdd(e.GetPosition);
                }
                if (index < 0)
                    return;
                if (index == rowIndex)
                    return;
                if (index == dg.Items.Count - 1)
                {
                    MessageBox.Show("Last line can't moove");
                    return;
                }
                if (dg.Name == "dg1")
                {
                    if (dgName == "dg2")
                    {
                        DataOfGrid changedProduct = yourlist2[rowIndex];
                        yourlist2.RemoveAt(rowIndex);
                        yourlist1.Insert(index, changedProduct);
                    }
                    else
                    {
                        DataOfGrid changedProduct = yourlist1[rowIndex];
                        yourlist1.RemoveAt(rowIndex);
                        yourlist1.Insert(index, changedProduct);
                    }
                }
                if (dg.Name == "dg2")
                {
                    if (dgName == "dg1")
                    {
                        DataOfGrid changedProduct = yourlist1[rowIndex];
                        yourlist1.RemoveAt(rowIndex);
                        yourlist2.Insert(index, changedProduct);
                    }
                    else
                    {
                        DataOfGrid changedProduct = yourlist2[rowIndex];
                        yourlist2.RemoveAt(rowIndex);
                        yourlist2.Insert(index, changedProduct);
                    }
                }
                dg1.ItemsSource = yourlist1;
                dg1.Items.Refresh();
                dg2.ItemsSource = yourlist2;
                dg2.Items.Refresh();
            }
    
            void DgSupp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                DataGrid dg = new DataGrid();
                if (sender is DataGrid)
                {
                    dg = (DataGrid)sender;
                }
                if (dg.Name == "dg1")
                {
                    rowIndex = GetCurrentRowIndexSupp(e.GetPosition);
                    dgName = dg.Name;
                }
                if (dg.Name == "dg2")
                {
                    rowIndex = GetCurrentRowIndexAdd(e.GetPosition);
                    dgName = dg.Name;
                }
                if (rowIndex < 0)
                    return;
                dg.SelectedIndex = rowIndex;
                DataOfGrid selectedEmp = dg.Items[rowIndex] as DataOfGrid;
                if (selectedEmp == null)
                    return;
                DragDropEffects dragdropeffects = DragDropEffects.Move;
                if (DragDrop.DoDragDrop(dg, selectedEmp, dragdropeffects)
                                    != DragDropEffects.None)
                {
                    dg.SelectedItem = selectedEmp;
                }
            }
    
            private bool GetMouseTargetRow(Visual theTarget, GetPosition position)
            {
                Rect rect = VisualTreeHelper.GetDescendantBounds(theTarget);
                Point point = position((IInputElement)theTarget);
                return rect.Contains(point);
            }
    
            private DataGridRow GetRowItemList1(int index)
            {
                if (dg1.ItemContainerGenerator.Status
                        != GeneratorStatus.ContainersGenerated)
                    return null;
                return dg1.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            }
    
            private DataGridRow GetRowItemList2(int index)
            {
                if (dg2.ItemContainerGenerator.Status
                        != GeneratorStatus.ContainersGenerated)
                    return null;
                return dg2.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            }
    
            private int GetCurrentRowIndexSupp(GetPosition pos)
            {
                int curIndex = -1;
                for (int i = 0; i < dg1.Items.Count; i++)
                {
                    DataGridRow itm = GetRowItemList1(i);
                    if (GetMouseTargetRow(itm, pos))
                    {
                        curIndex = i;
                        break;
                    }
                }
                return curIndex;
            }
    
            private int GetCurrentRowIndexAdd(GetPosition pos)
            {
                int curIndex = -1;
                for (int i = 0; i < dg2.Items.Count; i++)
                {
                    DataGridRow itm = GetRowItemList2(i);
                    if (GetMouseTargetRow(itm, pos))
                    {
                        curIndex = i;
                        break;
                    }
                }
                return curIndex;
            }
