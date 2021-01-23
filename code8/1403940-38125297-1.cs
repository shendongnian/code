    public class Drogon : MotherOfDragons
    {
        private String dragonsName;
        public override String DragonsName { get { return dragonsName; } }
        
        public void Change_DragonsName(String name)
		{
			dragonsName = name;
		}
    }
