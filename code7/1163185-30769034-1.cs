    QueueDescription queueDescription = new QueueDescription(queueName);
	string queuePolicyName = "SendPolicy";
	string queuePrimaryKey = SharedAccessAuthorizationRule.GenerateRandomKey();
	SharedAccessAuthorizationRule queueSharedAccessPolicy = new SharedAccessAuthorizationRule(queuePolicyName, queuePrimaryKey, new[] { AccessRights.Send });
	queueDescription.Authorization.Add(queueSharedAccessPolicy);
	await _namespaceManager.CreateQueueAsync(queueDescription);
