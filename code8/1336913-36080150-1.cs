      // note "override"
      class Class : Add {
         public override int Number { get; set; }
         public override string Text { get; set; }
    
         public int NumberPlusOne()
         {
             return Number + 1;
         }
    
         public override void Print()
         {
             Console.WriteLine("Number is " + Number);
             Console.WriteLine("Text is " + Text);
         }
      }
