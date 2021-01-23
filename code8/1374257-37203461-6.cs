    using System;
    using Word = Microsoft.Office.Interop.Word;
    using System.Reflection;
    
    namespace WordHelpers
    {
        class MyWordHelpers
        {   
            public static string GetBuiltInDocumentProperty(Word.Document oDoc, string propertyName)
            {
                object oDocBuiltInProps;
    
                oDocBuiltInProps = oDoc.BuiltInDocumentProperties;
                Type typeDocBuiltInProps = oDocBuiltInProps.GetType();
    
                //get the property
                object oDocAuthorProp = typeDocBuiltInProps.InvokeMember("Item",
                                           BindingFlags.Default |
                                           BindingFlags.GetProperty,
                                           null, oDocBuiltInProps,
                                           new object[] { propertyName }); // <-- here you exploit the passed property 
    
                //get the property type
                Type typeDocAuthorProp = oDocAuthorProp.GetType();
    
                // return the property value
                return typeDocAuthorProp.InvokeMember("Value",
                                           BindingFlags.Default |
                                           BindingFlags.GetProperty,
                                           null, oDocAuthorProp,
                                           new object[] { }).ToString(); ;
            }
        }
    
    }
