    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Samples
    {
    	class PhoneListProcessor
    	{
    		const int MaxCount = 10000;
    		const int MaxDigits = 10;
    		Dictionary<int, bool> phoneNumberInfo = new Dictionary<int, bool>(MaxCount * MaxDigits);
    		public bool Process(IEnumerable<string> phoneNumbers, bool readToEnd)
    		{
    			phoneNumberInfo.Clear();
    			using (var e = phoneNumbers.GetEnumerator())
    			{
    				while (e.MoveNext())
    				{
    					if (Process(e.Current)) continue;
    					if (readToEnd)
    					{
    						while (e.MoveNext()) { }
    					}
    					return false;
    				}
    			}
    			return true;
    		}
    		bool Process(string phoneNumber)
    		{
    			var phoneNumberInfo = this.phoneNumberInfo;
    			int phoneCode = 0;
    			int digitPos = 0;
    			bool hasSuffix = true;
    			while (true)
    			{
    				phoneCode = 11 * phoneCode + (phoneNumber[digitPos] - '0' + 1);
    				bool isLastDigit = ++digitPos >= phoneNumber.Length;
    				bool isPhoneNumber;
    				if (!phoneNumberInfo.TryGetValue(phoneCode, out isPhoneNumber))
    				{
    					phoneNumberInfo.Add(phoneCode, isLastDigit);
    					if (isLastDigit) return true;
    					hasSuffix = false;
    				}
    				else
    				{
    					if (isPhoneNumber) return false;
    					if (isLastDigit)
    					{
    						if (hasSuffix) return false;
    						phoneNumberInfo[phoneCode] = true;
    						return true;
    					}
    				}
    			}
    		}
    	}
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var processor = new PhoneListProcessor();
    			int testCount = int.Parse(Console.ReadLine());
    			for (int testIndex = 0; testIndex < testCount; testIndex++)
    			{
    				int count = int.Parse(Console.ReadLine());
    				var numbers = Enumerable.Range(0, count).Select(_ => Console.ReadLine());
    				bool readToEnd = testIndex + 1 < testCount;
                    bool valid = processor.Process(numbers, readToEnd);
    				Console.WriteLine(valid ? "YES" : "NO");
    			}
    		}
    	}
    }
