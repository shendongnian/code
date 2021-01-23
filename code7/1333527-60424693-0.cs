namespace PropertiesControls
{
    public class PropsControls
    {
        public static void PropesAndControls<TP, TC>(TP property, TC control) where TP : UserProperties where TC: UserControls
        {
            //your code here
        }
    }
}
A generic defines a behaviour that can be applied to a class. It is used in collections, where the same approach to handling an object can be applied regardless of the type of object. I.e, a list of strings or a list of integers can be handled using the same logic without having to differentiate between both specific types.
