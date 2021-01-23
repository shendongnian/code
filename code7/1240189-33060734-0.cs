       public ObjectTypeA OBJ1 = new ObjectTypeA();
       public ObjectTypeA OBJ1 = new ObjectTypeB();
       
       main() 
       {
           GetPlacedOrderIDFromTag(OBJ1);
           GetPlacedOrderIDFromTag(OBJ2);
       }
       public void GetPlacedOrderIDFromTag(ObjectTypeA _obj)
       {
           // I know this object has this property.  
           _obj.Prop1 = true;
       }
