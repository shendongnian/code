    var mySortedList = flpTest.Controls.OfType<Label>().OrderBy(x => Convert.ToInt32(x.Tag)).ToList();
    			flpTest.Controls.Clear(); //clear out the old unsorted controls
    			foreach(var itm in mySortedList)
    			{
    				flpTest.Controls.Add(itm);
    			}
    		}
