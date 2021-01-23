    public ref class TestDictionary
	{
	public:
		Dictionary<int, int>^ TestDictionaryElements()
		{
			Dictionary<int, int>^ h_result = gcnew Dictionary<int, int>();
			h_result->Add(1, 2);
			return (h_result);
		}
	}
