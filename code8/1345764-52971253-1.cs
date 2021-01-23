	internal class LogExtension : UnityContainerExtension
	{
		public LogExtension( ILogger logger )
		{
			_logger = logger;
		}
		#region UnityContainerExtension
		protected override void Initialize()
		{
			Context.Strategies.Add( new LoggingStrategy( _logger ), UnityBuildStage.PreCreation );
		}
		#endregion
		#region private
		private readonly ILogger _logger;
		private class LoggingStrategy : BuilderStrategy
		{
			public LoggingStrategy( ILogger logger )
			{
				_logger = logger;
			}
			#region BuilderStrategy
			public override void PreBuildUp( IBuilderContext context )
			{
				_logger.Log( $"Resolving {context.BuildKey.Type} for {context.OriginalBuildKey.Type}" );
			}
			#endregion
			#region private
			private readonly ILogger _logger;
			#endregion
		}
		#endregion
	}
