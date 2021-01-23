        private void testGrid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                Test currentTest = ((GalleryViewModel)DataContext).CurrentTests.ElementAtOrDefault(e.ListSourceRowIndex);
                if (currentTest != null)
                {
                    if ((int)e.Column.Tag < currentTest.Samples.Count && unboundSampleDrawIndex <= currentTest.Samples.Count - 1)
                    {
                        if (currentTest.IsReference)
                        {
                            e.Value = currentTest.Samples.ElementAt((int)e.Column.Tag).ABC;
                        }
                        else
                        {
                            e.Value = currentTest.Samples.ElementAt((int)e.Column.Tag).Delta;
                        }
                        unboundSampleDrawIndex++;
                    }
                    else
                    {
                        e.Value = "";
                    }
                    if (unboundSampleDrawIndex >= currentTest.Samples.Count)
                    {
                        unboundSampleDrawIndex = 0;
                    }
                }
            }
        }
