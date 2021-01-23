		for (int a = 1; a <= 1000; ++a)
        {
            int a3 = a * a * a;
			for (int b = a + 1; b <= 1000; ++b)
            {
                int b3 = b * b * b;
				for (int c = a + 1; c < b; ++c)
                {
                    int c3 = c * c * c;
                    int d3 = a3 + b3 - c3;
                    if (dict.HasKey(d3))
                    {
                        d = dict[d3];
                        Console.WriteLine($"{a} {b} {c} {d}");
                    }
                }
            }
        }
