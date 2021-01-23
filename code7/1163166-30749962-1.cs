    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            [ComVisible(true)]
            public class ComVisibleObjectForScripting
            {
                public void iFrameCheck(HTMLDocument FrameDoc)
                {
                    //Do what you want here with your FrameDoc
                    // the innerHTML will give you the content of the iframe
                }
            }
