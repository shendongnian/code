      static void Main(string[] args)
       {
			Asset.Members.DataMembers dataMember;
			
			dataMember = new Transit().DoNothing();
			Console.WriteLine(dataMember.MemberA);
			Console.ReadKey();
        }
