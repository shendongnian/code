    private void comboActiveStudentAssignmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        List<Border> borders = new List<Border>();
        // The list of border (focus rectangles) matches the combo of assignment types
        borders.Add(borderBibleReadingMain);
        borders.Add(borderBibleReadingClass1);
        borders.Add(borderBibleReadingClass2);
        borders.Add(borderMainHallStudent1);
        borders.Add(borderMainHallAssistant1);
        borders.Add(borderMainHallStudent2);
        borders.Add(borderMainHallAssistant2);
        borders.Add(borderMainHallStudent3);
        borders.Add(borderMainHallAssistant3);
        borders.Add(borderClass1Student1);
        borders.Add(borderClass1Assistant1);
        borders.Add(borderClass1Student2);
        borders.Add(borderClass1Assistant2);
        borders.Add(borderClass1Student3);
        borders.Add(borderClass1Assistant3);
        borders.Add(borderClass2Student1);
        borders.Add(borderClass2Assistant1);
        borders.Add(borderClass2Student2);
        borders.Add(borderClass2Assistant2);
        borders.Add(borderClass2Student3);
        borders.Add(borderClass2Assistant3);
        // Loop through the borders
        for(int iBorder = 0; iBorder < borders.Count; iBorder++)
        {
            // Is this border the active student assignment?
            if (comboActiveStudentAssignmentType.SelectedIndex == iBorder)
            {
                // Yes, so use a red brush for the background
                borders[iBorder].BorderBrush = Brushes.Red;
                // Now we must ensure the correct tab item is visible
                if(iBorder >= 0 && iBorder <= 2)
                {
                    expandTFGW.IsExpanded = true;
                    if (iBorder == 0)
                        tabTFGWReadingMainHall.IsSelected = true;
                    else if (iBorder == 1)
                        tabTFGWReadingClass1.IsSelected = true;
                    else if (iBorder == 2)
                        tabTFGWReadingClass2.IsSelected = true;
                }
                else if (iBorder >= 3 && iBorder <= 8)
                {
                    expandAYFM.IsExpanded = true;
                    tabAYFMStudentsMainHall.IsSelected = true;
                    if (iBorder == 3 || iBorder == 4)
                        tabMainHallItem1.IsSelected = true;
                    else if (iBorder == 5 || iBorder == 6)
                        tabMainHallItem2.IsSelected = true;
                    else if (iBorder == 7 || iBorder == 8)
                        tabMainHallItem3.IsSelected = true;
                }
                else if (iBorder >= 9 && iBorder <= 14)
                {
                    expandAYFM.IsExpanded = true;
                    tabAYFMStudentsClass1.IsSelected = true;
                    if (iBorder == 9 || iBorder == 10)
                        tabClass1Item1.IsSelected = true;
                    else if (iBorder == 11 || iBorder == 12)
                        tabClass1Item2.IsSelected = true;
                    else if (iBorder == 13 || iBorder == 14)
                        tabClass1Item3.IsSelected = true;
                }
                else if (iBorder >= 15)
                {
                    expandAYFM.IsExpanded = true;
                    tabAYFMStudentsClass2.IsSelected = true;
                    if (iBorder == 15 || iBorder == 16)
                        tabClass2Item1.IsSelected = true;
                    else if (iBorder == 17 || iBorder == 18)
                        tabClass2Item2.IsSelected = true;
                    else if (iBorder == 19 || iBorder == 20)
                        tabClass2Item3.IsSelected = true;
                }
                borders[iBorder].BringIntoView();
            }
            else
            {
                // No, so set the background to transparent so we can't see it.
                borders[iBorder].BorderBrush = Brushes.Transparent;
            }
        }
    }
