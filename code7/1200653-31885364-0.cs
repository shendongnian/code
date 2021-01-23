    public void CombineUDAs( ObservableCollection<Tuple<object, object>> UDAs )
       {
           for(outer=0; outer<UDAs.Count; outer++)
              for (inner = outer; inner<UDAs.Count; inner++)
                 if(outer != inner && (UDAs[inner].item1 == UDAs[outer].item1) && (UDAs[inner].item2 == UDAs[outer].item2))
                    //Add to collection
       }
