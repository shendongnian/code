    public class Test
    {
        public void TestCall()
        {
            SendParameter sendParameter;
            IWebReferenceWrapper wrapper;
            //Pseudo
            if (Customer == A)
            {
                sendParameter = new AParam();
                wrapper = new WebreferenceAWrapper();
            }
            else if(Customer == B)
            {
                sendParameter = new BParam();
                wrapper = new WebreferenceBWrapper();
            }
        }
    }
    public class WebreferenceAWrapper : IWebReferenceWrapper
    {
        public string Send(SendParameter param)
        {
            //Cast AParam and call send method
            return "A";
        }
    }
    public class WebreferenceBWrapper : IWebReferenceWrapper
    {
        public string Send(SendParameter param)
        {
            //Cast BParam and call send method
            return "B";
        }
    }
    public interface IWebReferenceWrapper
    {
        string Send(SendParameter param);
    }
    public abstract class SendParameter
    {
    }
    public class AParam : SendParameter
    {
        public string[] Mobiles { get; set; }
        public string[] Messages { get; set; }
    }
    public class BParam : SendParameter
    {
        public string Mobiles { get; set; }
        public string Messages { get; set; }
    }
