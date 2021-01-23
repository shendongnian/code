    public class ButtonsGroupController : MonoBehaviour
    {
        // List of all children buttons 
        private readonly List<Button> _buttons;
        
        // Last pressed button index
        private int _lastId = -1;
         
        void Start(){
            // Look for all buttons (children of this GO - scrollview)
        	_buttons = GetComponentsInChildren<Button>();
    
        	// Add event listener for buttons
        	for(var i = 0; i < _buttons.Count; i++){
        		var index = i;
        		_buttons[index].onClick.AddListener(() => ButtonPressed(index));
        	}
        	
        }
    
        // Resolve buttons press event
        private void ButtonPressed(int index){
            // The same button has been pressed
        	if(_lastId == index)
        		return;
    
        	// Update the last selected button sprite - to normal state
        	// _buttons[_lastId]....
    
        	// Update the last id
        	_lastId = index;
    
        	// Update the sprite of newly pressed button
        	// _buttons[_lastId]....
        }
    }
