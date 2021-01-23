        // First Way
        public List<MemberTransaction> GetMemberTransactions(string socSecNo)
        {
            var orderedListOfData = Manager.MemberTransactions
                                    .Where(m => m.SocSecNo == socSecNo)
                                    .OrderByDescending(m => m.TranDate).ToList();
            return orderedListOfData;
        }
    
       
    
         // Second Way
         public List<MemberTransaction> GetMemberTransactions(string socSecNo)
         {
             var orderedListOfData = (from m in Manager.MemberTransactions
                                      where m.SocSecNo == socSecNo
                                      orderby m.TranDate descending
                                      select m).ToList();
             return orderedListOfData;
          }
