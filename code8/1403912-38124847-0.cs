      public short GoodDeal 
        {
           get {return _goodDeal; }
           set 
           {
              if (NotGoodDeal(value))
              {
                  if ( UserConfirmDeal()  )
                  {
                      _goodDeal = value;
                      RaisePropertyChange();
                  }
              } 
           }
        }
