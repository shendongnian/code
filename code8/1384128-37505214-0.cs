        public ICollectionView myCVSWL { get; set; }
    internal SavedMemorySWL[] MemoriesSWL = new SavedMemorySWL[MAX_ROWS_SWL];
    .
    .
    .
     Global.MW.DataGridMemoryTable.Dispatcher.Invoke(new Action(() =>
                {
                    if (Global.MW != null)
                    {
                        myCVSWL = CollectionViewSource.GetDefaultView(SavedMemorySWLObservableCollection);
                        Global.MW.DataGridMemoryTable.ItemsSource = myCVSWL;    // SavedMemorySWLObservableCollection;
                        Global.MW.DataGridMemoryTable.Items.Refresh();
                        Global.MW.textBoxFileName.Text = memoryRows.FileName;
                    }
                }));
    .
    .
    .
    
    
    
    
                            int k = 0;
                        foreach (var item in myCVSWL.OfType<SavedMemorySWL>())
                        {
                            memoryRows.MemoriesSWL[k].Frequency = item.Frequency;
                            memoryRows.MemoriesSWL[k].Time = item.Time;
                            memoryRows.MemoriesSWL[k].Days = item.Days;
                            memoryRows.MemoriesSWL[k].ITU_Station = item.ITU_Station;
                            memoryRows.MemoriesSWL[k].Language_Target_Remarks = item.Language_Target_Remarks;
                            memoryRows.MemoriesSWL[k].Program_Start_Stop = item.Program_Start_Stop;
                            memoryRows.MemoriesSWL[k].ATAUTOinductor = item.ATAUTOinductor;
                            memoryRows.MemoriesSWL[k].ATAUTOcapacitor = item.ATAUTOcapacitor;
                            memoryRows.MemoriesSWL[k].Antenna = item.Antenna;
                            memoryRows.MemoriesSWL[k].Scan = item.Scan;
                            memoryRows.MemoriesSWL[k].AT200PCinductor = item.AT200PCinductor;
                            memoryRows.MemoriesSWL[k].AT200PCcapacitor = item.AT200PCcapacitor;
                            k++;
                        }
