    // I. Declare type, and implement interface
    
    // if we can declare a type
    var obj1: MyNamespace.IObject;
    
    // and later create or get that object
    export class MyObj implements MyNamespace.IObject{
    	IdProperty: number;
    	Result: string;
    	ReLoad = (id: number) => {return id.toString()};	
    }
    
    // now we get the implementation
    obj1 = new MyObj();
    
    // TS knows what could do with the obj2
    // of type
    obj1.Result = obj1.ReLoad(obj1.IdProperty);
    
    // II. ASSERT - let TS know what is the type behind
    
    // Assert - say to TS:
    // I know that this object is of the expected type
    var obj2 = <MyNamespace.IObject>obj;
    
    // now TS is happy to trust that tese properties exist
    obj2.Result = obj2.ReLoad(obj2.IdProperty);
