    template<class Type>
    public ref abstract class MyNumericSerializerBase : IMySerializer<Type> 
    { 
    public:
        Type  GetValue(Type first, Type second)
        {
            return first + (second / 2); // The REAL advantage(and potential problems source) of C++\CLI templates
        }
     }
