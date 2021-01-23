        public void addRuleFilter(String TopicName, String SubscriptionName, String filterName,String expression)
        {
               MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connectionString);
            
            // Create a filtered subscription
            SqlFilter MyFilter = new SqlFilter(expression);
            SubscriptionClient mySubscriptionClient = factory.CreateSubscriptionClient(TopicName, SubscriptionName);
            try
            {
                mySubscriptionClient.RemoveRule("$Default");//delete  le MatchALL
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            mySubscriptionClient.AddRule(filterName, MyFilter);//add my Filter
        }
