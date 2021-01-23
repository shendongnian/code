    		List<Dictionary<string, object>> listaDeDicionarios = new List<Dictionary<string, object>>()
			{
				new Dictionary<string,object>()
				{
					{"chave1","valor um"},
					{"chave2","dois"},
					{"chave3",true}
				},
				new Dictionary<string,object>()
				{
					{"chave4",4},
					{"chave5",DateTime.Now},
					{"chave6",long.MaxValue},
					{"chave7","..."}
				},
				new Dictionary<string,object>()
				{
					{"chave8","utf string áéí / &url"},
					{"chave9",null},
					{"chave10",String.Empty},
					{"chave11",new List<string>(){"aaa","bbb","ccc","oh my god, it's a miracle!"}}
				}
			};
