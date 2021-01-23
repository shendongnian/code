    public class LoadDiagram 
    {
        public static Dictionary<int, float> diagramaCarga = new Dictionary<int, float>();
        // this is a "static block" which acts like a constructor for static objects,
        // as static classes do not use constructors.
        // If I got the syntax correct, I've never actually used one of these.
        static LoadDiagram(){ // !!edited this line!!
            diagramaCarga.Add(0, 4.2F);
            diagramaCarga.Add(1, 4F);
            diagramaCarga.Add(2, 3.6F);
            diagramaCarga.Add(3, 3.4F);
            diagramaCarga.Add(4, 3.2F);
            diagramaCarga.Add(5, 3F);
        }
    }
