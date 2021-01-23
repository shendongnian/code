    public class Form1 : Form 
    {
          public Dictionary<string, Box> Boxes { get; } = new Dictionary<string, Box>();
    
          public Form1()
          {
              Pallet p = new Pallet();
              p.b1.Size = 5;
              p.b1.Size = 10;
    
              Boxes.Add("b1", p.b1);
          }
    }
