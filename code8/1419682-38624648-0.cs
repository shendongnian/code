    Code
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    using AutoMapper;
     
    namespace ConsoleApplication2
    {
    public class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class DataDto
    {
        public string FirstName { get; set; }
        public string No { get; set; }
    }
    public class ObjectModifier<TModel>
    {
        public ObjectModifier()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<string, string>().ConvertUsing(s => string.IsNullOrEmpty(s) ? s : s.Trim());
                c.CreateMap<TModel, TModel>();
                Mapper.AssertConfigurationIsValid();
            });
        }
        public TModel StringTrimmer(TModel model)
        {
            Mapper.AssertConfigurationIsValid();
            var mappedObj = Mapper.Map<TModel, TModel>(model);
            return mappedObj;
        }
    }
    public static class ObjectConverter
    {
        public static T2 ToObject<T1, T2>(T1 val)
        {
            return Mapper.DynamicMap<T1, T2>(val);
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {
            var doc = new Data()
            {
                FirstName = "Foo ",
                LastName = "ooF"
            };
            ObjectModifier<Data> objMod = new ObjectModifier<Data>();
            var result = objMod.StringTrimmer(doc);  //Good 
            var result2 = ObjectConverter.ToObject<Data, DataDto>(doc);  //Good
            var result3 = objMod.StringTrimmer(doc);   //Error
        }
    }
