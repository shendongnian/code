		int num=407;
		int nnum=num;
		string ss = num.ToString();
		int a=0;
		int b=0;string aa=" ";
		double newA=0;
		
		for(int i=0 ; i < ss.Length ; i++)
		{
			if(num > 0)
			{
				if(num < 10)
				{
					num = num+10;
					
				}
					a=num%10;
					aa += a+" ,";
					string s = num.ToString();
					string str=s.Remove(s.Length-1,1);
					s=str;
					b=int.Parse(s);
					newA += Math.Pow(a,3);
					Console.WriteLine("((({0})))",newA);
					num=b;
					Console.WriteLine(aa);
					num=int.Parse(str);
		}
				if(nnum==newA)
					
				{
					Console.WriteLine("\n\n\n\n {0} is a strong number .... !",nnum);
				}
		
		}
