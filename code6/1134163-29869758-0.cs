    list = NET.createGeneric('System.Collections.Generic.List',...
      {'System.Int32'},100);
    list.Add(5)
    list.Add(6)
    
    for i = 0:list.Count - 1
       disp(list.Item(i))
    end
