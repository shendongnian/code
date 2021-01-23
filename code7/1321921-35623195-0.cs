    public GTIFlightSegmentMap()
            {
                Id(x => x.ID);
               
                Component(x => x.Destination, m =>
                {
                    m.Map(y => y.Code).Column("DestinationCode");
    
                });
                Component(x => x.Origin, m =>
                {
                    m.Map(y => y.Code).Column("OriginCode");
    
                });
               ;       
                References(x => x.Parent).Not.Nullable();
              
    
            }
        }
