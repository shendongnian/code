    @{
        int numberOfColumns = 3;
        int currentItemIndex = 0;
        for (int currentColumnIndex = 1; currentColumnIndex <= numberOfColumns; currentColumnIndex++)
        {
            //Create a new column
            <div id="column-@currentColumnIndex">
                //Loop populate column with items
                @while (currentItemIndex < bar.Count() * currentColumnIndex / numberOfColumns)
                {
                    baz = bar.ElementAt(currentItemIndex);
                    //Add each item
                    <input type="checkbox" id="foo-@currentItemIndex" checked='@baz.CheckIt' />@baz.DisplayText
                    currentItemIndex++;
                }
            </div>
        }
    
    }
