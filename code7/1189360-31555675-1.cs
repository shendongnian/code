    (This is C++/CLI, copied from my own code and variables renamed. You can easily convert it to C#)
    public ref class CTestCase abstract
    {
    public:
      static Test_ID Type (Test_ID i_enTest)
      {
        return i_enTest- static_cast<Test>(Number(i_enTest));
      }
      static Test_ID Type (int i_iTest)
      {
        return static_cast<Test_ID>(i_iTest- Number(i_iTest));
      }
      static int Number (Test_ID i_enTest)
      {
        int iNumber = static_cast<int>(i_enTest) % static_cast<int>(Test_ID::Type_MASK);
        return iNumber;
      }
      static int Number (int i_iTest)
      {
        int iNumber = i_iTest% static_cast<int>(Test_ID::Type_MASK);
        return iNumber;
      }
    };
