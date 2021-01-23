    var bList = new List<Budget.budget_data>();
            for (var i = 0; i < bList.Count; i++)
            {
                for (var j = i + 1; j < bList.Count; j++)
                {
                    if (bList[i].Range == bList[j].Range)
                    {
                        //Perform your action
                    }
                }
            }
