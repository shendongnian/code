public delegate void ErrorHandler(string result);
public class BaseClass
{
   public event ErrorHandler OnError;
   protected void RaiseErrorEvent(string result)
   {
     OnError?.Invoke(result);
   }
 }
public class SampleClass:BaseClass
{
   public void Error(string s)
   {
     base.RaiseErrorEvent(s);
   }
}
