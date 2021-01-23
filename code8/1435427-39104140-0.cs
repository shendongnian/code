    int last = lowest;
    for (int i = lowest; i <= highest; i++)
    {
    int curr = (from int btn in collection/datatable where btn.ID == i select btn.ID).first;
    
    if (curr == (last + 1))
    {
    curr = i;
    }
    else
    {
    ++last
    curr = last;
    }
    
      //make the button based on curr or not as needed
    
    ++last;
    }
    }
