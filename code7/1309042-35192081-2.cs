    using System;
    using System.Linq;
    					
    public class Program
    {	
    	public static string[][] SampleInput()
    	{
    		var sampleInput = new string[4][];
    		sampleInput[0] = new string[] { "id", "name", "variable1", "variable1", "variable2" };
    		sampleInput[1] = new string[] { "", "", "Fall 2000", "Fall 2001", "Fall 2000" };
    		sampleInput[2] = new string[] { "1", "abc", "1400", "1500", "1200" };
    		sampleInput[3] = new string[] { "2", "xyz", "1200", "1400", "1100" };
    		
    		return sampleInput;	
    	}
    	
    	public static Tuple<int, string, string, string, int>[] Unpivot(string[][] flattenedInput)
    	{
    		var variables = (flattenedInput[0]).Skip(2).ToArray();
    		var falls = (flattenedInput[1]).Skip(2).ToArray();
    		var idNameValues = flattenedInput.Skip(2).Select(idNameValue => Tuple.Create(idNameValue[0], idNameValue[1], idNameValue.Skip(2))).ToArray();
    		
    		var output =
    			idNameValues
    				.SelectMany(idNameValue => variables
    					.Zip(falls, (variable, fall) => Tuple.Create(variable, fall))
    					.Zip(idNameValue.Item3, (variableFall, val) => Tuple.Create(variableFall.Item1, variableFall.Item2, val))
    					.Select((variableFallVal, i) => Tuple.Create(i + 1, Convert.ToInt32(idNameValue.Item1), idNameValue.Item2, variableFallVal.Item1, variableFallVal.Item2, variableFallVal.Item3))
    				)
    			    .OrderBy(rowId_ => Tuple.Create(rowId_.Item1, rowId_.Item2))
    			    .Select((_NameVariableFallValue, i) => Tuple.Create(i + 1, _NameVariableFallValue.Item3, _NameVariableFallValue.Item4, _NameVariableFallValue.Item5, Convert.ToInt32(_NameVariableFallValue.Item6)))
    			    .ToArray();
    		
    		return output;	
    	}
    	
    	public static void Main()
    	{
    		var flattenedData = SampleInput();
    		var normalisedData = Unpivot(SampleInput());
    		
    		Console.WriteLine("SampleInput =");
    		foreach (var row in SampleInput())
    		{
    			Console.WriteLine(Tuple.Create(row[0], row[1], row[2], row[3], row[4]).ToString());
    		}		
    		
    		Console.WriteLine("\nOutput =");
    		foreach (var row in normalisedData)
    		{
    			Console.WriteLine(row.ToString());
    		}
    	}
    }
