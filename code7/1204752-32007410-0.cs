    object[] dbOutput = itemsWS.getItemInfo(itemLi[(int)button.Tag].ToString());
    object[] items = new object[] {
        dbOutput[1], //description
        dbOutput[2]  //sale_price
        //and so on
    };
    selectedItenOutputOrderTabGrid.Rows.Add(items);
