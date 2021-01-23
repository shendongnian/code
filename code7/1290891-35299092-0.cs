    private async Task<List<Instance>> GetAllInstances()
        {
            List<Instance> instanceResult = new List<Instance>();
            var service = assign GooglecomputeServiceObject;
            InstancesResource instancesResource = new InstancesResource(service);
            InstanceList instanceList = await instancesResource.List(your ProjectId, specify_Zone).ExecuteAsync();
            if (instanceList.Items != null)
                foreach (var item in instanceList.Items)
                {
                    instanceResult.Add(item);
                }
            return instanceResult;
        }
