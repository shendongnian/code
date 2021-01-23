    int[,] distanceMatrix = new int[5, 5] {   { 0, 16, 39, 9, 24 },
                                                { 16, 0, 36, 32, 54 },
                                                { 39, 36, 0, 37, 55 },
                                                { 9, 32, 37, 0, 21 },
                                                { 24, 54, 55, 21, 0 }
                                            };
            int cityOne = Convert.ToInt32(DropDownList1.SelectedValue);
            int cityTwo = Convert.ToInt32(DropDownList2.SelectedValue);
            var distance = distanceMatrix[cityOne, cityTwo]; //the distance between cityOne and cityTwo;
