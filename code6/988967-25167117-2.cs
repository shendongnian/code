     var result = pO2GOEntities.po2go_gm_pos.ToList();
    
        if(!string.IsNullOrEmpty(txtone.Text))
        {
            result = result.Where(x=>x.SomeCoulmn == txtone.Text);
        }
        if(!string.IsNullOrEmpty(txttow.Text))
        {
            result = result.Where(x=>x.SomeCoulmn == txttwo.Text);
        }
    --------------
    --------------
    --------------
    
    var finalResult = result.OrderBy(x => x.ID)           
                            .Skip(initialRow)           
                            .Take(finalRow - initialRow)
                            .ToList() ;
