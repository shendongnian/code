	using OpenNLP.Tools.SentenceDetect;
	namespace Test
	{
		internal class Program
		{
			private static readonly string currentDirectory = Environment.CurrentDirectory + "/../../";
			private static void Main(string[] args)
			{
				var inputText =
					"C#[note 2] (pronounced as see sharp) is a multi-paradigm programming language encompassing strong typing, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines. It was developed by Microsoft within its .NET initiative and later approved as a standard by Ecma (ECMA-334) and ISO (ISO/IEC 23270:2006). C# is one of the programming languages designed for the Common Language Infrastructure. C# is intended to be a simple, modern, general-purpose, object-oriented programming language.[7] Its development team is led by Anders Hejlsberg. The most recent version is C# 6.0, which was released on July 20, 2015.[8]";
				var sentenceDetector =
					new EnglishMaximumEntropySentenceDetector(currentDirectory + "../Resources/Models/EnglishSD.nbin");
				string[] sentences = sentenceDetector.SentenceDetect(inputText);
				string longest = sentences.OrderByDescending(s => s.Length).First();
			}
		}
	}
