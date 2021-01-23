    List<ButtonLabel> List = new List<ButtonLabel>();
    List.Add(new ButtonLabel(btn1,lbl1));
    List.Add(new ButtonLabel(btn2,lbl2));
    List.Add(new ButtonLabel(btn3,lbl3));
    ...
    ...
    List.ForEach(I => 
    {
        I.HideIfEmpty();
    });
