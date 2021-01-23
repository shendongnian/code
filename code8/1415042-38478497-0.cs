       <#@ output extension=".cs" #>
        <#
           using(SampleContext context = new SampleContext)
           {
           string queuename = context.Queuename.FirstOrDefault();
           }
        #>
        internal class NotSoConstantConstants
        {
           public const string QueueName = "<#= queuename #>";
        }
