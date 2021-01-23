    public class CustomButton<T> : Button {
        public T Data{get;set;}
        public CustomButton(T data){
            this.Data = data; //i didn't compile it, so data type might mismatch.
        }
    }
