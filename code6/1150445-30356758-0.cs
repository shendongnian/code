            JObject jObjectFull = (JObject)dynObjFullJArray[index];
            JArray jArrayFull = (JArray)jObjectFull[packageName];
            if (packageName == "hello")
            {
                if (ishello)
                {
                    ishellochck = false;
                    jArrayFull.RemoveAll();
                }
                jArrayFull.Add(JObject.FromObject(dynObjItem));
            }
            else
            {
                for (int i = 0, fullCount = jArrayFull.Count; i < fullCount; i++)
                {
                    int itemId = (int)jArrayFull[i].SelectToken(selectedIdOrderNo.Split('|')[0]);
                    if (dynObjItemId == itemId)
                    {
                        //Edit
                        flag = true;
                        jArrayFull[i] = JObject.FromObject(dynObjItem);
                        // Maybe break here?
                    }
                }
            }
