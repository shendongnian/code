    public class MenuElement {
    public Action DoAction; // method I want to be dynamic
    public MenuElement((text, height, width, etc), Action myMethod){
        DoAction = myMethod;
    }
    }
    
    MenuElement m1 = new MenuElement(..., new Action(() => {
    // your code here
    });
    MenuElement m2 = new MenuElement(..., new Action(() => {
    // your code here
    ));
    
    m1.DoAction(); // calls x()
    m2.DoAction(); // calls y()
